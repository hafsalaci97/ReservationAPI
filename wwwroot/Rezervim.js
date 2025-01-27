document.getElementById('reservationForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    let reservation = {
        FullName: document.getElementById('name').value,
        PhoneNumber: document.getElementById('phone').value,
        Email: document.getElementById('email').value,
        ReservationDate: document.getElementById('date').value,
        ReservationTime: document.getElementById('time').value + ':00', // Ensure seconds are included
    };

    console.log('Payload:', reservation);

    try {
        const response = await fetch('http://localhost:5133/api/Reservation', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(reservation),
        });

        if (response.ok) {
            alert('Reservation saved successfully!');
        } else {
            const errorDetails = await response.json().catch(() => ({}));
            console.error('Error details:', errorDetails);
            alert(`Error saving reservation: ${response.status} ${response.statusText}`);
        }
    } catch (error) {
        console.error('Error:', error);
        alert('Error connecting to the server.');
    }
});
