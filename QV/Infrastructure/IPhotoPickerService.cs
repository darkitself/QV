using System.IO;
using System.Threading.Tasks;

namespace QV.Infrastructure
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}