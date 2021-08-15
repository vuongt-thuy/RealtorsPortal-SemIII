using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.ViewModel
{
    public class DataPoint
    {
		public DataPoint(double y, string label)
		{
			this.label = label;
			this.y = y;
		}

		//Explicitly setting the name to be used while serializing to JSON.
		public string label = "";

		//Explicitly setting the name to be used while serializing to JSON.
		public Nullable<double> y = null;
	}
}
