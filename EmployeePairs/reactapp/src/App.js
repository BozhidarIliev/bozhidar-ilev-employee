import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import FileInput from './components/FileInput';
import ProjectTable from './components/ProjectTable';

function App() {
    const [projects, setProjects] = useState([]);

    const handleProcessFile = (file) => {
        const formData = new FormData();
        formData.append('file', file);

        fetch('https://localhost:7038/api/project/getprojects', {
            method: 'POST',
            body: formData,
        })
            .then((response) => response.json())
            .then((data) => {
                setProjects(data);
            })
            .catch((error) => {
                console.error('Error processing file:', error);
            });
    };

    return (
        <div className="container">
            <h1 className="my-4">Employee Project Viewer</h1>
            <FileInput onFileChange={handleProcessFile} />
            <h2 className="my-4">Common Projects</h2>
            {projects && projects.length > 0 ? <ProjectTable projects={projects} /> : <p>No common projects found.</p>}
        </div>
    );
}

export default App;