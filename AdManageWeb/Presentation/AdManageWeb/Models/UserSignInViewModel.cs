using System.ComponentModel.DataAnnotations;

namespace AdManage.Models
{
	public class UserSignInViewModel
	{
		[Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
		public string Password { get; set; }
	}
}
