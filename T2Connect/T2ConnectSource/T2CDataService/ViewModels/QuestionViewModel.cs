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
	public partial class QuestionViewModel: BaseViewModel<Question>
	{
		[JsonProperty("questionId")]
		public int QuestionId { get; set; }
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonIgnore]
		public bool Deactive { get; set; }
		[JsonProperty("post")]
		public PostViewModel PostVM { get; set; }
		[JsonProperty("answers")]
		public ICollection<AnswerViewModel> AnswersVM { get; set; }
		
		public QuestionViewModel(Question entity) : this()
		{
			FromEntity(entity);
		}
		
		public QuestionViewModel()
		{
			this.AnswersVM = new HashSet<AnswerViewModel>();
		}
		
	}
}
