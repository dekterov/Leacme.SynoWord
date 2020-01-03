using System.Collections.Generic;

namespace Leacme.Lib.SynoWord {
	public class DefinitionResults {
		public string Batchcomplete { get; set; }
		public Warnings Warnings { get; set; }
		public Query Query { get; set; }
	}

	public class Query {
		public Dictionary<string, PageId> Pages { get; set; }
	}

	public class PageId {
		public long Pageid { get; set; }
		public long Ns { get; set; }
		public string Title { get; set; }
		public string Extract { get; set; }
		public string Missing { get; set; }
	}

	public class Warnings {
		public Extracts Extracts { get; set; }
	}

	public class Extracts {
		public string WarningExtracts { get; set; }
	}
}