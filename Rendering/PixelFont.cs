namespace BrutalPong.Rendering;

internal static class PixelFont
{
    private static readonly IReadOnlyDictionary<char, byte[]> Glyphs = new Dictionary<char, byte[]>
    {
        ['0'] = [14, 17, 19, 21, 25, 17, 14],
        ['1'] = [4, 12, 4, 4, 4, 4, 14],
        ['2'] = [14, 17, 1, 2, 4, 8, 31],
        ['3'] = [30, 1, 1, 14, 1, 1, 30],
        ['4'] = [2, 6, 10, 18, 31, 2, 2],
        ['5'] = [31, 16, 16, 30, 1, 1, 30],
        ['6'] = [6, 8, 16, 30, 17, 17, 14],
        ['7'] = [31, 1, 2, 4, 8, 8, 8],
        ['8'] = [14, 17, 17, 14, 17, 17, 14],
        ['9'] = [14, 17, 17, 15, 1, 2, 12],
        ['A'] = [14, 17, 17, 31, 17, 17, 17],
        ['B'] = [30, 17, 17, 30, 17, 17, 30],
        ['C'] = [14, 17, 16, 16, 16, 17, 14],
        ['E'] = [31, 16, 16, 30, 16, 16, 31],
        ['G'] = [14, 17, 16, 23, 17, 17, 15],
        ['I'] = [14, 4, 4, 4, 4, 4, 14],
        ['L'] = [16, 16, 16, 16, 16, 16, 31],
        ['M'] = [17, 27, 21, 21, 17, 17, 17],
        ['N'] = [17, 25, 25, 21, 19, 19, 17],
        ['O'] = [14, 17, 17, 17, 17, 17, 14],
        ['P'] = [30, 17, 17, 30, 16, 16, 16],
        ['R'] = [30, 17, 17, 30, 20, 18, 17],
        ['S'] = [15, 16, 16, 14, 1, 1, 30],
        ['T'] = [31, 4, 4, 4, 4, 4, 4],
        ['U'] = [17, 17, 17, 17, 17, 17, 14],
        ['V'] = [17, 17, 17, 17, 17, 10, 4],
        ['W'] = [17, 17, 17, 21, 21, 21, 10],
        ['Y'] = [17, 17, 10, 4, 4, 4, 4],
        [' '] = [0, 0, 0, 0, 0, 0, 0],
        [':'] = [0, 4, 4, 0, 4, 4, 0],
        ['-'] = [0, 0, 0, 31, 0, 0, 0],
    };

    public static void Draw(PongRenderer renderer, string text, float x, float y, float scale, float red, float green, float blue)
    {
        foreach (var character in text)
        {
            if (Glyphs.TryGetValue(character, out var glyph))
            {
                for (var row = 0; row < glyph.Length; row++)
                for (var column = 0; column < 5; column++)
                    if ((glyph[row] & (1 << (4 - column))) != 0)
                        renderer.Rectangle(x + column * scale, y + row * scale, scale * 0.78f, scale * 0.78f, red, green, blue);
            }

            x += 6 * scale;
        }
    }
}
