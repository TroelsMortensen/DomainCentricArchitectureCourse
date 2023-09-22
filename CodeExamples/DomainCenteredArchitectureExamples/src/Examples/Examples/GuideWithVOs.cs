using DCAExamples.Core.Domain.Common.Exceptions;

namespace Examples;

public class GuideWithVOs
{
    private GuideId id;
    private UserId ownerId;
    private CategoryId belongsToCategoryId;

    public GuideWithVOs(GuideId id, UserId ownerId, CategoryId belongsToCategoryId)
    {
        this.id = id;
        this.ownerId = ownerId;
        this.belongsToCategoryId = belongsToCategoryId;
    }

    private void example(UserId owner, CategoryId category)
    {
        GuideId guideId = new GuideId(Guid.NewGuid());
        GuideWithVOs guide0 = new GuideWithVOs(guideId, owner, category);
        // GuideWithVOs guide1 = new GuideWithVOs(owner, category, guideId);

    }
}

public class Guide
{
    private Guid id;
    private Guid ownerId;
    private Guid belongsToCategoryId;

    public Guide(Guid id, Guid ownerId, Guid belongsToCategoryId)
    {
        this.id = id;
        this.ownerId = ownerId;
        this.belongsToCategoryId = belongsToCategoryId;
    }

    private void mymethod(Guid owner, Guid categoryId)
    {
        Guide guide0 = new Guide(Guid.NewGuid(), owner, categoryId);
        Guide guide1 = new Guide(owner, categoryId, Guid.NewGuid());
        Guide guide2 = new Guide(categoryId, Guid.NewGuid(), owner);

    }
}

public class CategoryId
{
    public Guid Value { get; private set; }

    public CategoryId(Guid value)
    {
        Value = value;
        if (value == null) throw new InvalidArgumentException("Cannot be null");
    }
}

public class UserId
{
}

public class GuideId
{
    public GuideId(Guid newGuid)
    {
        throw new NotImplementedException();
    }
}