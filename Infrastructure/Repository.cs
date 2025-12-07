using Ardalis.Specification;
using Domain.ShareKernel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class EfRepository<T>(DbContext dbContext) : RepositoryBase<T>(dbContext), IRepositoryBase<T>, IReadRepository<T>
    where T : class, IAggregateRoot;