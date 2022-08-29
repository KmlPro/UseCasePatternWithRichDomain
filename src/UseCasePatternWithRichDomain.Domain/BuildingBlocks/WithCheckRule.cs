namespace UseCasePatternWithRichDomain.BuildingBlocks;

public abstract class WithCheckRule
{
    protected void CheckRule(IBusinessRule? rule)
    {
        rule?.CheckIsBroken();
    }
}