namespace Levels.Generation
{
    public class PathStructureContainer : IPathStructureContainer
    {
        public PathStructureSo PathStructure { get; private set; }

        public PathStructureContainer(PathStructureSo pathStructure)
        {
            PathStructure = pathStructure;
        }
    }
}