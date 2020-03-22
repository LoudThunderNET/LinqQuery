# LinqQuery
Реализация сокрытия IQueryable при реализации репозиториев.

## Использование
var blog = await blogRepository.FindAsync(1);
var blogA = await blogRepository
                .ExcecuteQueryAsync(b => b
                .Where(t => t.UserId == 2)
                .Select(b => new 
                { 
                    b.CreationDate, 
                    b.Title, 
                    b.Posts 
                }).FirstOrDefault());
