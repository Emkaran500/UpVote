namespace UpVote.Repositories.Base;

using UpVote.Models;

public interface IDiscussionRepository : 
                        IGetAllAsync<Discussion>,
                        IGetByIdAsync<Discussion>,
                        ICreateAsync<Discussion> {}

public interface IDiscussionRepository<T> : 
                        IGetAllAsync<T>,
                        IGetByIdAsync<T>,
                        ICreateAsync<T>
                                where T : Discussion {}