document.getElementById('createPlanForm').addEventListener('submit', async function (e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const planData = {
        name: formData.get('name'),
        days: formData.get('days'),
        exercises: formData.get('exercises'),
        notes: formData.get('notes'),
    };

    try {
        const response = await fetch('/api/plans', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(planData),
        });

        if (response.ok) {
            alert('Plan saved successfully!');
            window.location.href = '/community'; // Redirect after saving
        } else {
            alert('Error saving the plan. Please try again.');
        }
    } catch (error) {
        console.error('Error:', error);
        alert('An unexpected error occurred.');
    }
});
