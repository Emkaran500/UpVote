namespace UpVote.Repositories.Base;

using UpVote.Models;

public interface IDiscussionRepository : 
                        IGetAllAsync<Discussion>,
                        IGetByIdAsync<Discussion>,
                        ICreateAsync<Discussion> {}

public interface IDiscussionRepository<TProduct> : 
                        IGetAllAsync<TProduct>,
                        IGetByIdAsync<Discussion>,
                        ICreateAsync<TProduct>
                                where TProduct : Discussion {}