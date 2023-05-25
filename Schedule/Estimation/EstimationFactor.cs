using DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Estimation {
    public interface EstimationFactor<T> {
        double GetVerdict(T entity);
        double GetWeight();
    }
}
