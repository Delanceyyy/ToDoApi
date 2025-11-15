import TodoPageClient from "./TodoPageClient";

export default async function Home() {
  const res = await fetch("http://localhost:5175/api/todoitems", {
    cache: "no-store",
  });

  const todos = await res.json();

  return <TodoPageClient initialTodos={todos} />;
}
