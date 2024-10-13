﻿using System;

namespace DataAccess;

public interface CrudBase<T> where T : class
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<T> GetByIdAsync(Guid id);
	Task CreateAsync(T entity);
	Task UpdateAsync(T entity);
	Task DeleteAsync(Guid id);
}