"use client";

import { AiFillEdit } from "react-icons/ai";
import { AiFillDelete } from "react-icons/ai";

type Todo = {
  id: number;
  title: string;
  isComplete: boolean;
  categoryId: number | null;
  categoryName: string | null;
  categoryColor: string | null;
};

interface TodoListProps {
  todos: Todo[];
  // ⭐ 新增两个 props：编辑与删除事件
  onEdit: (todo: Todo) => void;
  onDelete: (id: number) => void;
}


const TodoList = ({ todos, onEdit, onDelete }: TodoListProps) => {
  return (
    <div className="overflow-x-auto w-full flex justify-center mt-6">
      <table className="table w-full max-w-4xl">
        <thead>
          <tr className="bg-gray-100">
            <th className="text-left">Title</th>
            <th className="text-left">Status</th>
            <th className="text-left">Category</th>
            <th className="text-left">Color</th>

            {/* ⭐ 新增 Actions 列 */}
            <th className="text-left">Actions</th>
          </tr>
        </thead>

        <tbody>
          {todos.map((t) => (
            <tr key={t.id} className="odd:bg-gray-50 even:bg-white hover:bg-gray-100 transition-colors">
              <td className="py-2">{t.title}</td>
              <td className="py-2">{t.isComplete ? "✅ Done" : "⌛ Pending"}</td>
              <td className="py-2">{t.categoryName ?? "—"}</td>
              <td className="py-2">
                {t.categoryColor ? (
                  <span
                    className="px-2 py-1 rounded text-white"
                    style={{ backgroundColor: t.categoryColor }}
                  >
                    {t.categoryColor}
                  </span>
                ) : (
                  "—"
                )}
              </td>

              {/* ⭐ 新增 Action 图标 */}
              <td className="py-2 flex gap-3">
                {/* 编辑按钮 */}
                <button onClick={() => onEdit(t)}>
                  <AiFillEdit size={20} className="text-blue-600 hover:text-blue-800" />
                </button>

                {/* 删除按钮 */}
                <button onClick={() => onDelete(t.id)}>
                  <AiFillDelete size={20} className="text-red-600 hover:text-red-800" />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default TodoList;





