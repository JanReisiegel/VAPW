using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_02
{
    class A
    {
		private int cislo;

		public int Cislo
		{
			get { return cislo; }
			set { if(value > 0 && value < 100) cislo = value; }
		}
	}
}
