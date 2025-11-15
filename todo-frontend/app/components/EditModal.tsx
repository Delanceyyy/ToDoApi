"use client";

import { useState, useEffect } from "react";

interface EditModalProps {
  open: boolean;
  todo: any | null;
  onCancel: () => void;
  onConfirm: (updatedTodo: any) => void;
}

export default function EditModal({ open, todo, onCancel, onConfirm }: EditModalProps) {
  const [title, setTitle] = useState("");
  const [categoryId, setCategoryId] = useState<number | null>(null);

  // 填充旧数据
  useEffect(() => {
    if (todo) {
      setTitle(todo.title);
      setCategoryId(todo.categoryId);
    }
  }, [todo]);

  if (!open || !todo) return null;

  return (
    <div className="fixed inset-0 bg-black/50 flex items-center justify-center z-50">
      <div className="bg-white p-6 rounded-xl w-full max-w-md shadow-lg">
        <h2 className="text-xl font-bold mb-4">Edit Task</h2>

        <input
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          className="w-full border rounded p-2 mb-4"
        />

        <select
          value={categoryId ?? ""}
          onChange={(e) =>
            setCategoryId(e.target.value ? Number(e.target.value) : null)
          }
          className="w-full border rounded p-2 mb-4 bg-white"
        >
          <option value="">No Category</option>
          <option value="1">Study</option>
          <option value="2">Work</option>
          <option value="3">Other</option>
        </select>

        <div className="flex justify-end space-x-3 mt-4">
          <button
            onClick={onCancel}
            className="px-4 py-2 bg-gray-200 rounded hover:bg-gray-300"
          >
            Cancel
          </button>

          <button
            onClick={() =>
              onConfirm({
                ...todo,
                title,
                categoryId,
              })
            }
            className="px-4 py-2 bg-purple-700 text-white rounded hover:bg-purple-600"
          >
            Save
          </button>
        </div>
      </div>
    </div>
  );
}
