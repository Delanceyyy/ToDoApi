// app/page.tsx (Next.js 13+ with App Router)

export default async function Home() {
  const res = await fetch("http://localhost:5175/api/todoitems", {
    cache: "no-store",
  });

  const todos = await res.json();

  return (
    <main style={{ padding: 20, fontFamily: "sans-serif" }}>
      <h1>✅ Todo List from .NET API</h1>

      <ul>
        {todos.map((t: any) => (
          <li key={t.id}>
            {t.title} — {t.isComplete ? "✅ Done" : "⌛ Pending"}
          </li>
        ))}
      </ul>
    </main>
  );
}


