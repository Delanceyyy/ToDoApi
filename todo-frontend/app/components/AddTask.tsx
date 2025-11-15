"use client";

import { useState } from "react";
import { AiOutlinePlus } from "react-icons/ai";

const AddTask = ({ refresh }: { refresh: () => void }) => {
  const [open, setOpen] = useState(false);
  const [title, setTitle] = useState("");
  const [categoryId, setCategoryId] = useState<number | null>(null);

  const handleAdd = async () => {
    if (!title.trim()) {
      alert("Title is required!");
      return;
    }

    const newTodo = {
      title,
      isComplete: false,
      categoryId,
    };

    const res = await fetch("http://localhost:5175/api/todoitems", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newTodo),
    });

    if (!res.ok) {
      alert("❌ Failed to add task");
      return;
    }

    setOpen(false);
    setTitle("");
    setCategoryId(null);
    alert("✅ Task added!");

    window.location.reload();
  };

  return (
    <>
      {/* 🚩ADD NEW TASK BUTTON */}
      <div className="w-full flex justify-center mt-4">
        <button
          onClick={() => setOpen(true)}
          className="
            w-full max-w-3xl
            bg-purple-700 text-white font-semibold
            py-3 rounded-xl
            flex items-center justify-center
            tracking-wide uppercase
            hover:bg-purple-600
            transition
          "
        >
          ADD NEW TASK
          <AiOutlinePlus className="ml-2" size={20} />
        </button>
      </div>

      {/* MODAL OVERLAY */}
      {open && (
        <div
          className="
            fixed inset-0 bg-black bg-opacity-50
            flex items-center justify-center
            z-50
          "
        >
          {/* MODAL CONTENT */}
          <div
            className="
              bg-white rounded-xl p-6 w-full max-w-md shadow-xl
            "
          >
            <h2 className="text-xl font-bold mb-4 text-center">
              Create New Task
            </h2>

            {/* TITLE INPUT */}
            <input
              type="text"
              value={title}
              onChange={(e) => setTitle(e.target.value)}
              placeholder="Task title"
              className="
                w-full border rounded p-2 mb-4
              "
            />

            {/* CATEGORY SELECT */}
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


            {/* BUTTONS */}
            <div className="flex justify-end space-x-3 mt-4">
              <button
                onClick={() => setOpen(false)}
                className="px-4 py-2 bg-gray-200 rounded hover:bg-gray-300 transition"
              >
                Cancel
              </button>

              <button
                onClick={handleAdd}
                className="
                  px-4 py-2 bg-purple-700 text-white rounded
                  hover:bg-purple-600 transition
                "
              >
                Add Task
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default AddTask;
