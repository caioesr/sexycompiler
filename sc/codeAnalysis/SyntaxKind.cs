namespace sexyc.codeAnalysis
{
    enum SyntaxKind
    {
        NumberToken,
        WhiteSpaceToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        BadToken,
        EOFToken,
        NumberExpression,
        BinaryExpression,
        ParenthesizedExpression
    }
}