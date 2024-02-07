using System.ComponentModel.DataAnnotations;

namespace ImovelAPI
{
    public class ImovelApi
    {
        public const string Imovel = "Imoveis";
        public ImovelApi(int id, string proprietario, string endereco)
        {
            Id = id;
            Proprietario = proprietario;
            Endereco = endereco;
        }

        [Required(ErrorMessage = "O campo 'ID' é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Proprietario' é obrigatório.")]
        public string Proprietario { get; set; }

        [Required(ErrorMessage = "O campo 'Endereco' é obrigatório.")]
        public string Endereco { get; set; }
    }
}
