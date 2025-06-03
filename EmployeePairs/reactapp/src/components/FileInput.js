import React from 'react';

function FileInput({ onFileChange }) {
    const handleFileChange = (event) => {
        const selectedFile = event.target.files[0];
        onFileChange(selectedFile);
    };

    return (
        <div className="mb-3">
            <input type="file" className="form-control" onChange={handleFileChange} />
        </div>
    );
}

export default FileInput;
