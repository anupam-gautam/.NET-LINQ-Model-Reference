public class hotelResults
	{
		public hotelInfo hotelInfo { get; set; }

		//make minimum rate without taxes using linq
		public decimal minPriceWithoutTaxes
		{
			get
			{
				return (decimal)rateDetails.rateDetails.Min(a => a.totalPriceWithoutTaxes);
			}
		}

		public RateDetails rateDetails { get; set; }
	}


public class RateDetails
	{
		public decimal PricePerNight
		{
			get
			{
				return rateDetails.Min(a => a.rooms.PricePerNight);
			}
		}
		public List<rateDetails> rateDetails { get; set; }
	}

    public class rateDetails
	{
		public string rateDetailCode { get; set; }
		public decimal? tax { get; set; }
		public decimal? IncludedTaxAmt
		{
			get
			{
				return taxesAndFees != null && taxesAndFees.taxesAndFees.Count > 0 ? taxesAndFees.taxesAndFees.Where(a => a.included).Select(a => a.amount).Sum() : 0;
			}
		}

		public decimal? totalPriceWithoutTaxes
		{
			get
			{
				return (decimal)totalPrice - IncludedTaxAmt;
			}
		}
		public cancelPoliciesInfo cancelPoliciesInfos { get; set; }
	}