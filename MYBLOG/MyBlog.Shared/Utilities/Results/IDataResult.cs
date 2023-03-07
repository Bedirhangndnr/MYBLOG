using MyBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Shared.Utilities.Results
{
    //Out type verilme sebebi, bir kategori tek başına da taşınmak istenebilir,
    //ilist ya da ienumerable olarak da taşınmak istenebilir. Bu yüzden iki
    //işlem için de farklı propertyler tanımlamak yerine bu şekildetek bir property
    //içinde istersel bir liste istersek tek bir entity taşıyabileceğiz.
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; } // new DAtaResult<Category>(ResultStatus.Success, category);
                               // new DAtaResult<Category>(ResultStatus.Success, category);
                               // new DataResult<IList>(ResultStatus.Success, categoryList);
    }
}
