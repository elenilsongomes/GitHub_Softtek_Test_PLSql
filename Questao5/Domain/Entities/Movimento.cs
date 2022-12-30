namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        //public Guid id { get; set; }
        public string idmovimento { get; set; }
        public string idcontacorrente { get; set; }
        public string? datamovimento { get; set; }
        public string tipomovimento { get; set; }
        public double valor { get; set; }

        public Movimento(string idmovimento, string idcontacorrente, string datamovimento, string tipomovimento, double valor)
        {
            //this.id = Guid.NewGuid();
            this.idmovimento = idmovimento;
            this.idcontacorrente = idcontacorrente;
            this.datamovimento = datamovimento;
            this.tipomovimento= tipomovimento;
            this.valor = valor;
        }
    }
}
