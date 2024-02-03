using Example09.Enemies.Types;

namespace Example09.Enemies
{
    public interface IEnemyVisitor
    {
        void Visit(Enemy enemy);

        void Visit(Ork ork);

        void Visit(Human human);

        void Visit(Elf elf);

        void Visit(Robot robot);
    }
}
