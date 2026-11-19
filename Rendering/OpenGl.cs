using System.Runtime.InteropServices;
using Brutal.GlfwApi;

namespace BrutalPong.Rendering;

internal sealed class OpenGl
{
    private const uint ColorBufferBit = 0x00004000;
    private const uint Quads = 0x0007;
    private const uint Projection = 0x1701;
    private const uint ModelView = 0x1700;

    private readonly GlClearColorDelegate _clearColor;
    private readonly GlClearDelegate _clear;
    private readonly GlViewportDelegate _viewport;
    private readonly GlMatrixModeDelegate _matrixMode;
    private readonly GlLoadIdentityDelegate _loadIdentity;
    private readonly GlOrthoDelegate _ortho;
    private readonly GlColor3fDelegate _color3f;
    private readonly GlBeginDelegate _begin;
    private readonly GlVertex2fDelegate _vertex2f;
    private readonly GlEndDelegate _end;

    public OpenGl()
    {
        _clearColor = Load<GlClearColorDelegate>("glClearColor"u8);
        _clear = Load<GlClearDelegate>("glClear"u8);
        _viewport = Load<GlViewportDelegate>("glViewport"u8);
        _matrixMode = Load<GlMatrixModeDelegate>("glMatrixMode"u8);
        _loadIdentity = Load<GlLoadIdentityDelegate>("glLoadIdentity"u8);
        _ortho = Load<GlOrthoDelegate>("glOrtho"u8);
        _color3f = Load<GlColor3fDelegate>("glColor3f"u8);
        _begin = Load<GlBeginDelegate>("glBegin"u8);
        _vertex2f = Load<GlVertex2fDelegate>("glVertex2f"u8);
        _end = Load<GlEndDelegate>("glEnd"u8);
    }

    public void BeginFrame(int width, int height)
    {
        _viewport(0, 0, width, height);
        _clearColor(0.035f, 0.055f, 0.105f, 1);
        _clear(ColorBufferBit);
        _matrixMode(Projection);
        _loadIdentity();
        _ortho(0, width, height, 0, -1, 1);
        _matrixMode(ModelView);
        _loadIdentity();
    }

    public void FillRectangle(float x, float y, float width, float height, float red, float green, float blue)
    {
        _color3f(red, green, blue);
        _begin(Quads);
        _vertex2f(x, y);
        _vertex2f(x + width, y);
        _vertex2f(x + width, y + height);
        _vertex2f(x, y + height);
        _end();
    }

    private static T Load<T>(ReadOnlySpan<byte> name) where T : Delegate
    {
        var address = Glfw.GetProcAddress(name);
        if (address == IntPtr.Zero)
            throw new InvalidOperationException($"OpenGL function {System.Text.Encoding.UTF8.GetString(name)} is unavailable.");

        return Marshal.GetDelegateForFunctionPointer<T>(address);
    }

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlClearColorDelegate(float red, float green, float blue, float alpha);
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlClearDelegate(uint mask);
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlViewportDelegate(int x, int y, int width, int height);
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlMatrixModeDelegate(uint mode);
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlLoadIdentityDelegate();
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlOrthoDelegate(double left, double right, double bottom, double top, double near, double far);
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlColor3fDelegate(float red, float green, float blue);
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlBeginDelegate(uint mode);
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlVertex2fDelegate(float x, float y);
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    private delegate void GlEndDelegate();
}
