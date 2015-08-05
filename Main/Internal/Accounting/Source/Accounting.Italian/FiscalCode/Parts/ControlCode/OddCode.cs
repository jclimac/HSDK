namespace EyeSoft.Accounting.Italian
{
	using System.Collections.Generic;
	using System.Linq;

	using EyeSoft.Collections.Generic;

	internal class OddCode
	{
		private static readonly IDictionary<char, int> codes =
			new Dictionary<char, int>()
				.AddRange(Enumerable.Range(0, 10).Select(x => new KeyValuePair<char, int>((char)('0' + x), x)))
				.AddRange(Enumerable.Range('A', 'Z' - 'A' + 1).Select((x, u) => new KeyValuePair<char, int>((char)x, u)));

		public OddCode(string partialCode)
		{
			var evenChars = partialCode.OddChars();

			var sum = evenChars.Sum(x => codes[x]);

			Total = sum;
		}

		public int Total { get; private set; }
	}
}