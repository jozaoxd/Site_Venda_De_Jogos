using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesMac.Models
{
    public class Games
    {
        [Key]
        public int GameId { get; set; }

        [Required(ErrorMessage = "O nome do jogo deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do jogo deve ser informada.")]
        [Display(Name = "Descrição do Jogo")]
        [MinLength(20, ErrorMessage = "A descrição curtadeve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "A descrição curta pode exceder {1} caracteres")]
        
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição detalhada do jogo deve ser informada")]
        [Display(Name = "Descrição detalhada do Jogo")]
        [MinLength(20, ErrorMessage = "A descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "A descrição detalhada pode exceder {1} caracteres")]

        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99,ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200,ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsGamePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
