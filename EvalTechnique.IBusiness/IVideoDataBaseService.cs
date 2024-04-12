using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace EvalTechnique.IBusiness
{
    [ServiceContract]
    public interface IVideoDataBaseService
    {
        [OperationContract]
        List<EBusiness.VideoDataBaseItem> GetItems();

        [OperationContract]
        List<EBusiness.Movie> GetMovies();

        [OperationContract]
        List<EBusiness.Serie> GetSeries();

        [OperationContract]
        List<EBusiness.VideoDataBaseItem> GetByTitle(string searchTitle);

        [OperationContract]
        void AddNewVideoItems(List<EBusiness.VideoDataBaseItem> videoDataBaseItems);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Test")]
        string Test();
    }
}
