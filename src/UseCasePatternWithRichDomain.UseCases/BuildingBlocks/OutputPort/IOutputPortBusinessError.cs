namespace UseCasePatternWithRichDomain.UseCases.BuildingBlocks.OutputPort
{
    public interface IOutputPortBusinessError
    {
        /// <summary>
        ///     Informs an business rule broken.
        /// </summary>
        /// <param name="message">Text description.</param>
        void WriteBusinessRuleError(string message);
    }
}
