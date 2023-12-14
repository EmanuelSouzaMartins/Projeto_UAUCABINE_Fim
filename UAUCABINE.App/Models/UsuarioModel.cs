namespace UAUCABINE.App.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
