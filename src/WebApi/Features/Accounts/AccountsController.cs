﻿using System.Net.Mime;
using Core.UseCases.Accounts.Commands.Withdraw;
using Core.UseCases.Accounts.Queries.GetUserAccount;
using Domain.Entities.Accounts;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Swashbuckle.AspNetCore.Filters;
using WebApi.Features.Accounts.Dtos.Requests;
using WebApi.Features.Accounts.Dtos.SwaggeExamples;

namespace WebApi.Features.Accounts;

[Route("accounts")]
[Consumes("application/json")]
public class AccountController : Controller
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// List of my accounts
    /// </summary>
    [EnableQuery(PageSize = 10)]
    [HttpGet("me")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<UserAccountsGetOut>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IQueryable<UserAccountsGetOut>>> Me()
    {
        // TODO: REMOVE
        var currentUserId = 1;
        var query = new GetUserAccountsQuery()
        {
            UserId = currentUserId
        };

        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    /// <summary>
    /// Withdraw from my account
    /// </summary>
    /// <returns>New Updated Account</returns>
    /// <response code="200">New Updated Account</response>
    [HttpPut("{accountId:int}/withdraw")]
    [SwaggerRequestExample(typeof(WithdrawRequestDto), typeof(WithdrawExamples))]
    [ProducesResponseType(typeof(Account), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType(typeof(ProblemDetails))]
    public async Task<ActionResult<Account>> Withdraw([FromBody] WithdrawRequestDto dto)
    {
        var currentUserId = 1;
        dto.UserId = currentUserId;
        var command = dto.Adapt<WithdrawCommand>();

        var result = await _mediator.Send(command);
        
        return Ok(result);
    }
}