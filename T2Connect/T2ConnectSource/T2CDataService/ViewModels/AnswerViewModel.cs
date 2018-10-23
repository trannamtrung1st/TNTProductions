using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2CDataService.Global;
using T2CDataService.Models;
using Newtonsoft.Json;

namespace T2CDataService.ViewModels
{
	public partial class AnswerViewModel: BaseViewModel<Answer>
	{
		[JsonProperty("answerId")]
		public int AnswerId { get; set; }
		[JsonProperty("inQuestionId")]
		public Nullable<int> InQuestionId { get; set; }
		[JsonIgnore]
		public bool Deactive { get; set; }
		[JsonProperty("post")]
		public PostViewModel PostVM { get; set; }
		[JsonProperty("question")]
		public QuestionViewModel QuestionVM { get; set; }
		
		public AnswerViewModel(Answer entity) : this()
		{
			FromEntity(entity);
		}
		
		public AnswerViewModel()
		{
		}
		
	}
}
