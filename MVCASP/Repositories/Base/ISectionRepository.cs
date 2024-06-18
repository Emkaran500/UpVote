namespace UpVote.Repositories.Base;

using UpVote.Models;

public interface ISectionRepository : 
                        IGetAllAsync<Section>,
                        IGetByIdAsync<Section>,
                        ICreateAsync<Section>,
                        IDeleteAsync,
                        IUpdateAsync<Section> {}

public interface ISectionRepository<T> : 
                        IGetAllAsync<T>,
                        IGetByIdAsync<T>,
                        ICreateAsync<T>,
                        IDeleteAsync,
                        IUpdateAsync<T>
                                where T : Section {}