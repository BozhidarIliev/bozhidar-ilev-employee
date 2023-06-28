import React from 'react';

function ProjectTable({ projects }) {
    return (
        <table className="table">
            <thead>
                <tr>
                    <th>Employee ID #1</th>
                    <th>Employee ID #2</th>
                    <th>Project ID</th>
                    <th>Days Worked</th>
                </tr>
            </thead>
            <tbody>
                {projects.map((project, index) => (
                    <tr key={index}>
                        <td>{project.employee1}</td>
                        <td>{project.employee2}</td>
                        <td>{project.projectID}</td>
                        <td>{project.daysWorked}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default ProjectTable;
