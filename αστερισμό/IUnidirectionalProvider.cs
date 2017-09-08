using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace αστερισμό.Media.Animation
{
    public interface IUnidirectionalProvider<T>
    {
        T GetProgressValue(T originValue, T destinationValue, double progress);
    }
}
