using System;
using SanPellgrino;

namespace GdaxApi.Models
{
	public class Candle
	{
		public DateTime Time { get; set; }
		public decimal Low { get; set; }
		public decimal High { get; set; }
		public decimal Open { get; set; }
		public decimal Close { get; set; }
	    public decimal Volumn { get; }
	    public decimal Volume { get; set; }

	    public Candle(long time, decimal low, decimal high, decimal open, decimal close, decimal volumn)
	    {
	        Time = time.ToDateTimeFromEpoch();
	        Low = low;
	        High = high;
	        Open = open;
	        Close = close;
	        Volumn = volumn;
	    }
	}
}