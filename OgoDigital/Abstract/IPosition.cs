using System.Collections.Generic;

namespace OgoDigital.Abstract
{
    public interface IPosition
    {
        void StartMove(List<int> maxPoints, string moves);
    }
}
