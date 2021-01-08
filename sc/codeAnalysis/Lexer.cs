using System.Collections.Generic;

namespace sexyc.codeAnalysis
{
    class Lexer
    {
        private readonly string text;
        private int position;
        private List<string> diagnostics = new List<string>();

        public Lexer(string Text)
        {
            text = Text;
        }

        public IEnumerable<string> Diagnostics => diagnostics;

        private char Current
        {
            get
            {
                if (position >= text.Length)
                    return '\0';

                return text[position];
            }
        }

        private void Next()
        {
            position++;
        }

        public SyntaxToken NextToken()
        {
            // <numbers>
            // + - * / ( )
            // <whitespace>

            if (position >= text.Length)
                return new SyntaxToken(SyntaxKind.EOFToken, position, "\0", null);

            if (char.IsDigit(Current))
            {
                var start = position;

                while (char.IsDigit(Current))
                    Next();

                var length = position - start;
                var Text = text.Substring(start, length);
                if (!int.TryParse(Text, out var value))
                    diagnostics.Add($"The number {text} isn't valid Int32.");

                return new SyntaxToken(SyntaxKind.NumberToken, start, Text, value);
            }

            if (char.IsWhiteSpace(Current))
            {
                var start = position;

                while (char.IsWhiteSpace(Current))
                    Next();

                var length = position - start;
                var Text = text.Substring(start, length);
                return new SyntaxToken(SyntaxKind.WhiteSpaceToken, start, Text, null);
            }

            if (Current == '+')
                return new SyntaxToken(SyntaxKind.PlusToken, position++, "+", null);
            else if (Current == '-')
                return new SyntaxToken(SyntaxKind.MinusToken, position++, "-", null);
            else if (Current == '*')
                return new SyntaxToken(SyntaxKind.StarToken, position++, "*", null);
            else if (Current == '/')
                return new SyntaxToken(SyntaxKind.SlashToken, position++, "/", null);
            else if (Current == '(')
                return new SyntaxToken(SyntaxKind.OpenParenthesisToken, position++, "(", null);
            else if (Current == ')')
                return new SyntaxToken(SyntaxKind.CloseParenthesisToken, position++, ")", null);

            diagnostics.Add($"ERROR: bad character input: '{Current}'");
            return new SyntaxToken(SyntaxKind.BadToken, position++, text.Substring(position - 1, 1), null);
        }
    }
}