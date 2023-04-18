namespace ValueObjectExamples;

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