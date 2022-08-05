

using TryFitnessBL.Controller;

namespace TryFitnessBL
{
    public abstract class ControllerBase
    {
        protected IDataSaver dataSaver = new SerializeDataSaver(); //new DatabaseDataSaver()
        protected void Save(string fileName, object item)
        {
            dataSaver.Save(fileName, item);
        }
        protected T Load<T>(string fileName) where T : class
        {
            return dataSaver.Load<T>(fileName);
        }
    }
}
