using System.Net;

namespace Client.Domain.SharedContext
{
    public class Util
    {
        public async Task<ReturnBase> TryCatch(Func<Task<ReturnBase>> func)
        {
            try
            {
                var returnedFunc = await Task.Run(func);
                return returnedFunc;
            }
            catch (UnprocessableEntityException ex)
            {
                return new ReturnBase(HttpStatusCode.UnprocessableEntity, ex.ValidationErros, ex.Message);
            }
            catch(DataNotFoundException ex)
            {
                return new ReturnBase(HttpStatusCode.NotFound, null, ex.Message);
            }
            catch (Exception ex)
            {
                return new ReturnBase(HttpStatusCode.InternalServerError, null, ex.Message);
            }
        }

        public void ValidationEntity<T>(T entityClass) where T : EntityBase
        {
            if (entityClass.IsInvalid())
                throw new UnprocessableEntityException(entityClass.Notifications.Select(x => x.Message), "Ocorreram erros de validação.");
        }

        public static string GetTableName<T>()
        {
            return typeof(T).FullName.Replace(".", "_");
        }
    }
}
