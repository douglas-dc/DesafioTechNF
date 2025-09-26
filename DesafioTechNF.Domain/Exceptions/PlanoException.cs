namespace DesafioTechNF.Domain.Exceptions
{
    public static class PlanoException
    {
        public static int ObterLimiteMensal(PlanoTipo plano)
        {
            return plano switch
            {
                PlanoTipo.Mensal => 12,
                PlanoTipo.Trimestral => 20,
                PlanoTipo.Anual => 30,
                _ => throw new ArgumentOutOfRangeException(nameof(plano))
            };
        }
    }
}