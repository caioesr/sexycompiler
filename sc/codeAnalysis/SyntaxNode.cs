using System.Collections.Generic;

namespace sexyc.codeAnalysis
{
    abstract class SyntaxNode
    {
        public abstract SyntaxKind Kind { get; }

        public abstract IEnumerable<SyntaxNode> GetChildren();
    }
}