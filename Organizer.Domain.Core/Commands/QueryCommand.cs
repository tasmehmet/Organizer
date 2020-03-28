﻿using MediatR;

 namespace Organizer.Domain.Core.Commands
{

    public class QueryCommand
    {

    }
    public class QueryCommand<T> : QueryCommand, IRequest<T>
        where T : class
    {
    }
}
