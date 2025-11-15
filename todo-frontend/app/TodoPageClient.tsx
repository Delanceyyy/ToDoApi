"use client";

import { useState } from "react";
import AddTask from "./components/AddTask";
import TodoList from "./components/TodoList";
import DeleteModal from "./components/DeleteModal";
import EditModal from "./components/EditModal";

export default function TodoPageClient({ initialTodos }: { initialTodos: any[] }) {
  const [todos, setTodos] = useState(initialTodos);

  // ---------------- REFRESH ----------------
  const refreshTodos = async () => {
    const res = await fetch("http://localhost:5175/api/todoitems", { cache: "no-store" });
    const data = await res.json();
    setTodos(data);
  };

  // ----------- DELETE ----------
  const [deleteId, setDeleteId] = useState<number | null>(null);
  const [isDeleteOpen, setIsDeleteOpen] = useState(false);

  const openDelete = (id: number) => {
    setDeleteId(id);
    setIsDeleteOpen(true);
  };

  const handleDelete = async () => {
    if (!deleteId) return;

    await fetch(`http://localhost:5175/api/todoitems/${deleteId}`, {
      method: "DELETE",
    });

    setIsDeleteOpen(false);
    refreshTodos();
  };

  // ---------------- EDIT ----------------
  const [editOpen, setEditOpen] = useState(false);
  const [editTodo, setEditTodo] = useState<any | null>(null);

  const openEdit = (todo: any) => {
    setEditTodo(todo);
    setEditOpen(true);
  };

  const handleEditConfirm = async (updatedTodo: any) => {
    await fetch(`http://localhost:5175/api/todoitems/${updatedTodo.id}`, {
      method: "PUT", // 或者 PATCH，看你后端怎么写
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        title: updatedTodo.title,
        categoryId: updatedTodo.categoryId ?? null,
        isComplete: updatedTodo.isComplete,
      }),
    });

    setEditOpen(false);
    setEditTodo(null);
    refreshTodos();
  };

  // ---------------- UI ----------------

  return (
    <main className="max-w-4xl mx-auto mt-6">
      {/* ADD */}
      <AddTask refresh={refreshTodos} />

      {/* LIST */}
      <TodoList 
        todos={todos}
        onDelete={openDelete}
        onEdit={openEdit}
      />

      {/* DELETE MODAL */}
      <DeleteModal 
        isOpen={isDeleteOpen}
        onClose={() => setIsDeleteOpen(false)}
        onConfirm={handleDelete}
      />

      {/* EDIT MODAL */}
      <EditModal
        open={editOpen}
        todo={editTodo}
        onCancel={() => setEditOpen(false)}
        onConfirm={handleEditConfirm}
      />
      
    </main>
  );
}
