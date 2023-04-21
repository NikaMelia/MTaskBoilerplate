using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Pagination;
using HotChocolate.Types.Relay.Descriptors;
using MTask.Extensions.Core.Pagination;
using MTask.Extensions.Core.Pagination.Helpers;

namespace MTask.Extensions.HotChocolate
{
    public static class CommonObjectTypeDescriptorExtensions
    {
        public static INodeDescriptor<TRuntimeType, TId> UseIdField<TRuntimeType, TId>
        (this IObjectTypeDescriptor<TRuntimeType> descriptor,
            Expression<Func<TRuntimeType, TId>> idPropertyAccessor)
        {
            var nodeDescriptor = descriptor
                .ImplementsNode()
                .IdField(idPropertyAccessor);

            return nodeDescriptor;
        }

        /// <summary>
        /// Adds `databaseId` field to GraphQL Type 
        /// This is actual id in persistence store 
        /// </summary>
        /// <remarks>
        /// GraphQL id is base64("")
        /// </remarks>
        public static IObjectTypeDescriptor<TRuntimeType> UseDatabaseId<TRuntimeType, TId>
            (this IObjectTypeDescriptor<TRuntimeType> descriptor, Func<TRuntimeType, TId> idPropertyAccessor)

        {
            descriptor.Field("databaseId").Resolve((f, d1) =>
            {
                var currentObj = f.Parent<TRuntimeType>();
                var idValue = idPropertyAccessor(currentObj);
                return idValue;
            });

            return descriptor;
        }

        /// <summary>
        /// Adds `databaseId` field to GraphQL Type 
        /// This is actual id in persistence store 
        /// </summary>
        /// <remarks>
        /// GraphQL id is base64("")
        /// </remarks>
        public static IObjectTypeDescriptor<TRuntimeType> UseConnectionPaging<TRuntimeType, TId>
            (this IObjectTypeDescriptor<TRuntimeType> descriptor, Func<TRuntimeType, TId> idPropertyAccessor)

        {
            descriptor.Field("databaseId").Resolve((f, d1) =>
            {
                var currentObj = f.Parent<TRuntimeType>();
                var idValue = idPropertyAccessor(currentObj);
                return idValue;
            });

            return descriptor;
        }

        public static IObjectFieldDescriptor UseMTaskPaging<
            TNodeType, TOrderByType>(
            this IObjectFieldDescriptor descriptor,
            Func<IResolverContext, TOrderByType, CursorPagingRequest, Task<Connection>> connectionResolver,
            PagingOptions options = default) where TNodeType : class, IOutputType
        {
            descriptor
                .UsePaging<TNodeType>(options: options)
                .Argument("orderBy", a => a.Type<NonNullType<InputObjectType<TOrderByType>>>())
                .Resolve(context =>
                {
                    CursorPagingRequest paginationRequest = new CursorPagingRequest()
                    {
                        After = context.ArgumentValue<string?>("after"),
                        First = context.ArgumentValue<int?>("first"),
                        Before = context.ArgumentValue<string?>("before"),
                        Last = context.ArgumentValue<int?>("last")
                    };

                    TOrderByType orderingRequest = context.ArgumentValue<TOrderByType>("orderBy");

                    return connectionResolver(context, orderingRequest, paginationRequest);
                });

            return descriptor;
        }

        public static Connection<T> ToConnection<T>(this PaginationResult<T> paginationResult)
        {
            var edges = paginationResult.Edges.Select(e => new Edge<T>(e.Node, e.Cursor)).ToList();
            var connectionPageInfo = new ConnectionPageInfo(paginationResult.Info.HasNextPage,
                paginationResult.Info.HasPreviousPage, paginationResult.Info.StartCursor,
                paginationResult.Info.EndCursor);

            return new Connection<T>(edges, connectionPageInfo, paginationResult.GetTotalCountAsync);
        }

    }
}