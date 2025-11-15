interface DeleteModalProps{
    isOpen: boolean;
    onClose: () => void;
    onConfirm: () => void;
}

export default function DeleteModal({ isOpen, onClose, onConfirm }: DeleteModalProps){
    if (!isOpen) return null;

    return (
        <div className="fixed inset-0 bg-black bg-opacity-50 flex justify-center items-center">
        <div className="bg-white p-6 rounded-xl shadow-xl w-80">
            <div className="text-lg mb-4">Are you sure you want to delete this task?</div>

            <div className="flex justify-end space-x-3">
            <button
                className="px-4 py-2 rounded bg-gray-300"
                onClick={onClose}
            >
                Cancel
            </button>

            <button
                className="px-4 py-2 rounded bg-red-600 text-white"
                onClick={onConfirm}
            >
                Yes
            </button>
            </div>
        </div>
        </div>
    );
    }