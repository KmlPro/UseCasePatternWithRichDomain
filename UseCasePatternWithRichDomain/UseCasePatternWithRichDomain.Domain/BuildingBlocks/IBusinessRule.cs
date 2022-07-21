namespace UseCasePatternWithRichDomain.BuildingBlocks;

public interface IBusinessRule
{
    /// <summary>
    ///     The method should return a business exception if validation fails
    /// </summary>
    void CheckIsBroken();
}